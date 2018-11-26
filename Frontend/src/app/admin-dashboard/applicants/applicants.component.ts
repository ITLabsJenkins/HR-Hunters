import { Component, OnInit } from '@angular/core';
import { Applicant } from 'src/app/models/applicant.model';
import { Subscription } from 'rxjs';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-ad-applicants',
  templateUrl: './applicants.component.html',
  styleUrls: ['./applicants.component.scss']
})
export class ADApplicantsComponent implements OnInit {
  
  applicantsCount = {
    all: 15
  };
  applicants: Applicant[] = [];
  postsPerPage = 10;
  currentPage = 1;
  currentSortBy = 'Expires';
  currentSortDirection = 1;
  currentFilter = 'All';
  private applicationsSub: Subscription;

  constructor(private adminService: AdminService) {}

  ngOnInit() {
  }

  onChangedPage(pageData: any) {
    this.currentPage = pageData.pageIndex + 1;
    this.postsPerPage = pageData.pageSize;
    this.currentFilter = pageData.filterBy;
    this.currentSortBy = pageData.sortedBy;
    this.currentSortDirection = pageData.sortDirection;
    this.adminService.getApplications(
      this.postsPerPage,
      this.currentPage,
      this.currentSortBy,
      this.currentSortDirection,
      this.currentFilter
    );
  }

  onFilter(pageData: any) {
    this.currentPage = pageData.pageIndex;
    this.postsPerPage = pageData.pageSize;
    // this.currentFilter = the cliecked el;
    this.currentSortBy = pageData.sortedBy;
    this.currentSortDirection = pageData.sortDirection;
    this.adminService.getApplications(
      this.postsPerPage,
      this.currentPage,
      this.currentSortBy,
      this.currentSortDirection,
      this.currentFilter
    );
  }

  onSort(pageData: any) {
    this.currentPage = pageData.pageIndex;
    this.postsPerPage = pageData.pageSize;
    this.currentFilter = pageData.filterBy;
    // this.currentSortBy = the cliecked el;
    this.currentSortDirection = pageData.sortDirection + 1;
    this.adminService.getApplications(
      this.postsPerPage,
      this.currentPage,
      this.currentSortBy,
      this.currentSortDirection,
      this.currentFilter
    );
  }

  chooseStatus(event: any) {
    const currentStatus = event.target.innerText;
  }

}
