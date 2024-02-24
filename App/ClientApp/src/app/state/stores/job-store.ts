import {createStore} from "@ngneat/elf";
import {addEntities, deleteEntities, selectAllEntities, updateEntities, withEntities} from "@ngneat/elf-entities";
import {Job} from "../../core/models/job";
import {JobService} from "../../features/jobs/services/job.service";

export class JobStore {
  private store = createStore({ name: 'jobs' }, withEntities<Job, 'jobId'>({idKey: 'jobId'}));
  jobs$ = this.store.pipe(selectAllEntities());

  constructor(private jobService: JobService) {
  }

  // load job data
  load() {
    this.jobService.getAll().subscribe(
      {
        next: (newJobs) => {
          console.log('loading jobs');
          this.store.update(addEntities(newJobs));
        },
        error: (error) => {
          console.error('Failed to load jobs', error);
        }
      }
    );
  }

  // load category jobs
  loadByCategoryId(categoryId: string){
    this.jobService.getByCategory(categoryId).subscribe(
      {
        next: (newJobs) => {
          console.log('loading jobs by category');
          this.store.update(addEntities(newJobs));
        },
        error: (error) => {
          console.error('Failed to load jobs', error);
        }
      }
    );
  }

  // load job by id
  loadById(jobId: string){
    this.jobService.get(jobId).subscribe(
      {
        next: (newJob) => {
          console.log('loading a job by id');
          this.store.update(addEntities(newJob));
        },
        error: (error) => {
          console.error('Failed to load a job', error);
        }
      }
    );
  }

  // add job
  add(job: Job) {
    this.jobService.create(job).subscribe({
      next: (newJob: Job) => {
        this.store.update(addEntities(newJob));
      },
      error: (error) => {
        console.error('Failed to add job', error);
      }
    });
  }

  // Update an existing job
  update(job: Job) {
    this.jobService.update(job).subscribe({
      next: (updatedJob: Job) => {
        this.store.update(updateEntities(updatedJob.jobId, updatedJob));
      },
      error: (error) => {
        console.error('Failed to update a job', error);
      }
    });
  }

  // Delete a job
  delete(job: Job) {
    this.jobService.delete(job).subscribe({
      next: () => {
        this.store.update(deleteEntities(job.jobId));
      },
      error: (error) => {
        console.error('Failed to delete a job', error);
      }
    });
  }
}
