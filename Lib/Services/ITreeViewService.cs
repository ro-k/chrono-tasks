using Lib.DTOs;

namespace Lib.Services;

public interface ITreeViewService
{
    Task<TreeViewDto> GetAllByUserContext();
}