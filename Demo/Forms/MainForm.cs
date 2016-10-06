using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ShelfInspectorAI.Api;
using ShelfInspectorAI.Boosting;
using ShelfInspectorAI.GeneticAlgorithm;
using ShelfInspectorDataModel.Infrastructure.Dto;
using ShelfInspectorDataModel.Model;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Util;

namespace Demo.Forms
{
    internal delegate void EcoModelProcessing(EcoModel model);

    public partial class MainForm : Form
    {

        private readonly LinkedList<ImageContainer> _trainingSetFiles;
        private readonly LinkedList<ImageContainer> _holdingSetFiles;

        private Adaboost _adaboost;

        private static int _numberOfGenerations;
        private static int _numberOfRuns;
        private static int _currentRun;

        private static EcoGeneticAlgorithm _ecoGeneticAlgorithm;

        public MainForm()
        {
            InitializeComponent();

            DisableResearchControls();
            ITrainingFilesProvider provider = new NtfsFileNamesProvider();

            var trainingFileNames = provider.GetFileNames(@"~/../../../dataset/training");
            var holdingFileNames = provider.GetFileNames(@"~/../../../dataset/test");

            _holdingSetFiles = new LinkedList<ImageContainer>();
            _trainingSetFiles = new LinkedList<ImageContainer>();

#warning Stinky-stinky repeatable code!!!
            foreach (TrainingImage trainingSetFileName in trainingFileNames)
            {
                ImageContainer tmp = ImageHandler.LoadImage(trainingSetFileName.File);
                tmp.BelongsToClass = trainingSetFileName.BelongsToClass;
                _trainingSetFiles.AddLast(tmp);
            }
 
            foreach (TrainingImage holdingSetFileName in holdingFileNames)
            {
                ImageContainer tmp = ImageHandler.LoadImage(holdingSetFileName.File);
                tmp.BelongsToClass = holdingSetFileName.BelongsToClass;
                _holdingSetFiles.AddLast(tmp);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            _numberOfGenerations = (int)numberOfGenerationsUpDown.Value;

            progressReportLabel.Text = @"Running evolution for "+ _numberOfGenerations +@" generations...";

            _adaboost = new Adaboost(_trainingSetFiles);

            if (ReasearchCheckBox.Checked)
            {
                _ecoGeneticAlgorithm = new EcoGeneticAlgorithm(1000, _numberOfGenerations, 0.02,
                _holdingSetFiles, _trainingSetFiles,
                new GaProgressReporter(progressTextBox, progressBar, true), new EvolutionDoneCallBack(ModelProcessing));

                progressTextBox.AppendText("Suppressing output for the genetics...\r\n-------------------------------------------------------------------\r\n");

                _numberOfRuns = (int)researchUpDown.Value;
                researchStatusLabel.Text = @"Collecting data for " + _numberOfRuns + @" runs";
                _ecoGeneticAlgorithm.Run();
            }
            else
            {
                _ecoGeneticAlgorithm = new EcoGeneticAlgorithm(1000, _numberOfGenerations, 0.02,
                _holdingSetFiles, _trainingSetFiles,
                new GaProgressReporter(progressTextBox, progressBar, false), new EvolutionDoneCallBack(ModelProcessing));
                _ecoGeneticAlgorithm.Run();
            }
            

        }

        private class GaProgressReporter : IGaProgressReporter
        {
            private readonly TextBox _outputTextBox;
            private readonly ProgressBar _progressBar;
            private readonly bool _suppressOutput;

            public GaProgressReporter(TextBox outputTextBox, ProgressBar progressBar, bool suppressOutput)
            {
                _outputTextBox = outputTextBox;
                _progressBar = progressBar;
                _suppressOutput = suppressOutput;
            }

            public void ReportProgress(ref GaProgressInfo progressInfo)
            {
                if (!_suppressOutput)
                {
                    _outputTextBox.AppendText(progressInfo.ToString());
                }
                _progressBar.Value = (int)(progressInfo.GenerationNumber / (double)_numberOfGenerations * 100);
            }
        }

        private class EvolutionDoneCallBack : IEvolutionDoneCallback
        {
            private readonly EcoModelProcessing _modelProcessingCallback;

            public EvolutionDoneCallBack(EcoModelProcessing modelProcessingCallback)
            {
                _modelProcessingCallback = modelProcessingCallback;
            }

            public void EvolutionDone(EcoModel model)
            {
                _modelProcessingCallback(model);
            }
        }

        private void ModelProcessing(EcoModel model)
        {
            progressReportLabel.Text = @"Training AdaBoost";
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Marquee;

            BackgroundWorker adaboostTrainBgw = new BackgroundWorker();
            adaboostTrainBgw.DoWork += adaboostTrainBgw_DoWork;
            adaboostTrainBgw.RunWorkerCompleted += adaboostTrainBgw_RunWorkerCompleted;
            adaboostTrainBgw.RunWorkerAsync(model);

        }

        void adaboostTrainBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DemonstrateClassification();
        }

        void adaboostTrainBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            _adaboost.Train((EcoModel)e.Argument);
        }

        private void DemonstrateClassification()
        {
           // MessageBox.Show("I am about to start the demonstration!", "ECO Features Demo", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);

            progressReportLabel.Text = @"Classifying";
            BackgroundWorker classificationDemonstrationBackgroundWorker = new BackgroundWorker();
            classificationDemonstrationBackgroundWorker.DoWork += classificationDemonstrationBackgroundWorker_DoWork;
            classificationDemonstrationBackgroundWorker.RunWorkerCompleted += classificationDemonstrationBackgroundWorker_RunWorkerCompleted;
            classificationDemonstrationBackgroundWorker.RunWorkerAsync();
        }

        private void classificationDemonstrationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressReportLabel.Text = @"Demo over";
            if (ReasearchCheckBox.Checked)
            {
                _currentRun++;
                researchProgressBar.Value = (int)(_currentRun / (double)_numberOfRuns * 100);
                if (_currentRun == _numberOfRuns)
                {
                    MessageBox.Show("Data collection over", "ECO Features Demo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    continueRuns();
                }
            }

        }

        private void continueRuns()
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;
            progressReportLabel.Text = @"Running evolution for " + _numberOfGenerations + @" generations...";
            _ecoGeneticAlgorithm.Run();
        }

        void classificationDemonstrationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            double fp = 0, correct = 0;
            foreach (ImageContainer image in _holdingSetFiles)
            {

                int classification = _adaboost.Run(image);

                if (classification != image.BelongsToClass && image.BelongsToClass == 0)
                    fp++;

                if (classification == image.BelongsToClass)
                    correct++;

               /* MessageBox.Show(
                    classification == 1 ? "I think that's a brocaded carp" : "I don't think that's a brocaded carp",
                    "ECO Features Demo");*/
            }


                progressTextBox.BeginInvoke(
                    new MethodInvoker(
                        () => progressTextBox.AppendText(String.Format("Correct rate: {0}%\r\n",
                            (correct/_holdingSetFiles.Count*100)))));

            //MessageBox.Show(String.Format("False positives: {0}%\n\rCorrect rate: {1}%\n\r", (fp/_holdingSet.Count*100), ), "ECO Features Demo");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Evolutionary constructed features framework demo.\n\r Recognizes brocaded carp.\n\r All (c) by Dmitry Ivanov & Alexander Zarubin", "ECO Features Demo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ReasearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox) sender).Checked)
            {
                EnableResearchControls();
            }
            else
            {
                DisableResearchControls();
            }
        }

        private void EnableResearchControls()
        {
            researchUpDown.Enabled = true;
            researchProgressBar.Enabled = true;
        }

        private void DisableResearchControls()
        {
            researchUpDown.Enabled = false;
            researchProgressBar.Enabled = false;
        }
    }
}
