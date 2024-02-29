import {createStore} from "@ngneat/elf";
import {
  addEntities,
  deleteEntities,
  selectAllEntities,
  selectAllEntitiesApply,
  updateEntities,
  withEntities
} from "@ngneat/elf-entities";
import {Activity} from "../../core/models/activity";
import {ActivityService} from "../../features/activities/services/activity-service";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ActivityStore {
  store = createStore({ name: 'activities' }, withEntities<Activity, 'activityId'>({idKey: 'activityId'}));
  activities$ = this.store.pipe(selectAllEntities());

  categoryActivities$ = this.store.pipe(selectAllEntitiesApply({mapEntity: e => e, filterEntity: e => e.categoryId !== null}));

  jobActivities$ = this.store.pipe(selectAllEntitiesApply({mapEntity: e => e, filterEntity: e => e.jobId !== null}));

  constructor(private activityService: ActivityService) {
  }

  // load activity data
  load() {
    this.activityService.getAll().subscribe(
      {
        next: (newActivities) => {
          console.log('loading activities');
          this.store.update(addEntities(newActivities));
        },
        error: (error) => {
          console.error('Failed to load activities', error);
        }
      }
    );
  }

  // load category activities
  loadByCategoryId(categoryId: string){
    this.activityService.getByCategory(categoryId).subscribe(
      {
        next: (newActivities) => {
          console.log('loading activities by category');
          this.store.update(addEntities(newActivities));
        },
        error: (error) => {
          console.error('Failed to load activities', error);
        }
      }
    );
  }

  // Delete a activity
  clearCategory(activityId: string) {
    this.activityService.clearCategory(activityId).subscribe({
      next: () => {

      },
      error: (error) => {
        console.error('Failed to clear categories for an activity', error);
      }
    });
  }

  // load category activities
  loadByJobId(jobId: string){
    this.activityService.getByJob(jobId).subscribe(
      {
        next: (newActivities) => {
          console.log('loading activities by job');
          this.store.update(addEntities(newActivities));
        },
        error: (error) => {
          console.error('Failed to load job activities', error);
        }
      }
    );
  }

  // Delete a activity
  clearJob(jobId: string) {
    this.activityService.clearJob(jobId).subscribe({
      next: () => {

      },
      error: (error) => {
        console.error('Failed to clear a job activity', error);
      }
    });
  }

  // load activity by id
  loadById(activityId: string){
    this.activityService.get(activityId).subscribe(
      {
        next: (newActivity) => {
          console.log('loading a activity by id');
          this.store.update(addEntities(newActivity));
        },
        error: (error) => {
          console.error('Failed to load a activity', error);
        }
      }
    );
  }

  // add activity
  add(activity: Activity) {
    this.activityService.create(activity).subscribe({
      next: (newActivity: Activity) => {
        this.store.update(addEntities(newActivity));
      },
      error: (error) => {
        console.error('Failed to add activity', error);
      }
    });
  }

  // Update an existing activity
  update(activity: Activity) {
    this.activityService.update(activity).subscribe({
      next: (updatedActivity: Activity) => {
        this.store.update(updateEntities(updatedActivity.activityId, updatedActivity));
      },
      error: (error) => {
        console.error('Failed to update a activity', error);
      }
    });
  }

  // Delete an activity
  delete(activity: Activity) {
    this.activityService.delete(activity).subscribe({
      next: () => {
        this.store.update(deleteEntities(activity.activityId));
      },
      error: (error) => {
        console.error('Failed to delete a activity', error);
      }
    });
  }
}
