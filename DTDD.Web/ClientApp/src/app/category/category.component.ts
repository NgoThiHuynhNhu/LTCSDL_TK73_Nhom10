import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  category: any = {
    id: 0,
    categoryName: "dienthoai",
    parentId: 0
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchCategory(2);
  }

  searchCategory(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/Category/search-category", x).subscribe(result => {
      this.categories = result;
      this.categories  = this.categories .data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.categories .page);
    console.log(this.categories .totalPages)
    if (this.categories.page < this.categories.totalPages) {
      let nextPage = this.categories.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Category/search-category", x).subscribe(result => {
        this.categories  = result;
        this.categories  = this.categories .data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.categories .page > 1) {
      let nextPage = this.categories .page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Category/search-category", x).subscribe(result => {
        this.categories  = result;
        this.categories  = this.categories.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.category = {
        id: 0,
        categoryName: "dienthoai",
        parentId: 0
      }
    }
    else {
      this.isEdit = true;
      this.category = this.categories.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addCategory() {
    var x = this.categories;
    x.id = parseInt(this.category.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/Category/create-category", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.category = res.data;
        this.isEdit = true;
        this.searchCategory(2);
        alert("New product has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateCategory() {
    var x = this.category;
    this.http.post("https://localhost:44395/api/Category/update-category", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.category = res.data;
        //this.isEdit = true;
        this.searchCategory(2);
        alert("New product has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteCategory(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.category = this.categories.data[index];
      var x:any  ={id: this.category.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/Category/delete-category", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchCategory(2);
          alert("You have successfully deleted!");
        }
        else {
          alert(res.message);
        }
      }, error => {
        alert(error);
      });

      }
  }
}
