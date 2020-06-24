import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  customer: any = {
    customerId: 0,
    customerName: "Nguyen Van A",
    customerPhone: "0123456789",
    customerMail: "nguyena@gmail.com"
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchCustomer(3);
  }

  searchCustomer(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/Customer/search-customer", x).subscribe(result => {
      this.customers = result;
      this.customers  = this.customers.data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.customers .page);
    console.log(this.customers .totalPages)
    if (this.customers.page < this.customers.totalPages) {
      let nextPage = this.customers.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Customer/search-customer", x).subscribe(result => {
        this.customers  = result;
        this.customers  = this.customers .data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.customers.page > 1) {
      let nextPage = this.customers .page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Customer/search-customer", x).subscribe(result => {
        this.customers  = result;
        this.customers  = this.customers.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.customer = {
        customerId: 0,
        customerName: "",
        customerPhone: "",
        customerMail: ""
      }
    }
    else {
      this.isEdit = true;
      this.customer = this.customers.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addCustomer() {
    var x = this.customers;
    x.id = parseInt(this.customer.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/Customer/create-customer", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.customer = res.data;
        this.isEdit = true;
        this.searchCustomer(3);
        alert("New customer has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateCustomer() {
    var x = this.customer;
    this.http.post("https://localhost:44395/api/Customer/update-customer", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.customer = res.data;
        //this.isEdit = true;
        this.searchCustomer(3);
        alert("New customer has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteCustomer(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.customer = this.customers.data[index];
      var x:any  ={id: this.customer.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/Customer/delete-customer", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchCustomer(3);
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
