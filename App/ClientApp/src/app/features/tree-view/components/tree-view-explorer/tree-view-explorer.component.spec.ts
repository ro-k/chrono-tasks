import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeViewExplorerComponent } from './tree-view-explorer.component';

describe('TreeViewComponent', () => {
  let component: TreeViewExplorerComponent;
  let fixture: ComponentFixture<TreeViewExplorerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TreeViewExplorerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TreeViewExplorerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
