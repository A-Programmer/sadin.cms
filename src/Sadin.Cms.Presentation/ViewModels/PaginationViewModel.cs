namespace Sadin.Cms.Presentation.ViewModels;

public sealed class PaginationViewModel
{
    private int? _pageIndex;
    public int? PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = _pageIndex <= 1 ? 1 : value;
    }

    private int? _pageSize;
    public int? PageSize
    {
        get => _pageSize;
        set => _pageSize = _pageSize < 1 ? 20 : value;
    }
}