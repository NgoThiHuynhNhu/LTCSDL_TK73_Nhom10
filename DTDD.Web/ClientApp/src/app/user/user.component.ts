import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  user: any = {
    userId: 0,
    username: "Nguyen Van A",
    password: "0123456789",
    name: "nguyena@gmail.com"
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchUser(3);
  }

  searchUser(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/User/search-user", x).subscribe(result => {
      this.users = result;
      this.users  = this.users.data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.users .page);
    console.log(this.users .totalPages)
    if (this.users.page < this.users.totalPages) {
      let nextPage = this.users.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/User/search-user", x).subscribe(result => {
        this.users  = result;
        this.users  = this.users .data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.users.page > 1) {
      let nextPage = this.users .page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/User/search-user", x).subscribe(result => {
        this.users  = result;
        this.users  = this.users.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.user = {
        userId: 0,
        username: "",
        password: "",
        name: ""
      }
    }
    else {
      this.isEdit = true;
      this.user = this.users.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addUser() {
    var x = this.users;
    x.id = parseInt(this.user.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/User/create-user", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.user = res.data;
        this.isEdit = true;
        this.searchUser(3);
        alert("New user has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateUser() {
    var x = this.user;
    this.http.post("https://localhost:44395/api/User/update-user", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.user = res.data;
        //this.isEdit = true;
        this.searchUser(3);
        alert("New user has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteUser(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.user = this.users.data[index];
      var x:any  ={id: this.user.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/User/delete-user", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchUser(3);
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
