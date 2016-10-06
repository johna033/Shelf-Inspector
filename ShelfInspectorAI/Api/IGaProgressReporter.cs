namespace ShelfInspectorAI.Api
{
    public interface IGaProgressReporter
    {
        void ReportProgress(ref GaProgressInfo progressInfo);
    }
}
