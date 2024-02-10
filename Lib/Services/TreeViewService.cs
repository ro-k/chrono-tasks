using Lib.DataAccess;
using Lib.DTOs;
using Lib.Models;

namespace Lib.Services;

public class TreeViewService : ITreeViewService
{
    private readonly ITreeViewDataAccess _treeViewDataAccess;

    public TreeViewService(ITreeViewDataAccess treeViewDataAccess)
    {
        _treeViewDataAccess = treeViewDataAccess;
    }

    public async Task<TreeViewDto> GetAllByUserContext()
    {
        var (categories, jobs, activities) = await _treeViewDataAccess.GetAllByUserContext(async reader =>
        {
            var categories = await reader.ReadAsync<Category>();
            var jobs = await reader.ReadAsync<Job>();
            var activities = await reader.ReadAsync<TreeViewActivityDto>();

            return (categories, jobs, activities);
        });

        return AssembleTreeView(categories, jobs, activities);
    }

    private TreeViewDto AssembleTreeView(IEnumerable<Category> categories, IEnumerable<Job> jobs,
        IEnumerable<TreeViewActivityDto> activities)
    {
        var treeViewCategories = categories.Select(x => (TreeViewCategoryDto)x).ToDictionary(x => x.CategoryId);
        var jobActivities = new Dictionary<Guid, List<TreeViewActivityDto>>();
        foreach (var activity in activities)
        {
            if (activity.CategoryId.HasValue &&
                treeViewCategories.TryGetValue(activity.CategoryId.Value, out var category))
            {
                category.TreeViewActivities.Add(activity);
            }

            if (!activity.JobId.HasValue) continue;
            
            if (!jobActivities.TryGetValue(activity.JobId.Value, out var list))
            {
                list = new List<TreeViewActivityDto>();
                jobActivities[activity.JobId.Value] = list;
            }

            list.Add(activity);

        }

        foreach (var job in jobs)
        {
            var treeViewJob = (TreeViewJobDto)job;
            if (jobActivities.TryGetValue(job.JobId, out var activitiesList))
            {
                treeViewJob.TreeViewActivities.AddRange(activitiesList);
            }

            if (treeViewCategories.TryGetValue(job.CategoryId, out var categoryDto))
            {
                categoryDto.TreeViewJobs.Add(treeViewJob);
            }
        }

        return new TreeViewDto { Categories = treeViewCategories.Values.ToList() };
    }
}