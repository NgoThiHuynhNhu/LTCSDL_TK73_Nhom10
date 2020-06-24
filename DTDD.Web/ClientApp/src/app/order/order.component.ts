import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  orders: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  order: any = {
    orderId: 0,
    customerId: 0,
    statusId: 0,
    delivererId: 0,
    totalPrice: "",
    deliveryAddress: ""

  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchOrder(2);
  }

  searchOrder(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/Order/search-order", x).subscribe(result => {
      this.orders = result;
      this.orders  = this.orders .data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.orders .page);
    console.log(this.orders .totalPages)
    if (this.orders.page < this.orders.totalPages) {
      let nextPage = this.orders.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Order/search-order", x).subscribe(result => {
        this.orders  = result;
        this.orders  = this.orders .data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.orders .page > 1) {
      let nextPage = this.orders .page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Order/search-order", x).subscribe(result => {
        this.orders  = result;
        this.orders  = this.orders.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.order = {
        orderId: 0,
        customerId: 0,
        statusId: 0,
        delivererId: 0,
        totalPrice: "",
        deliveryAddress: ""
      }
    }
    else {
      this.isEdit = true;
      this.order = this.orders.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addOrder() {
    var x = this.orders;
    x.id = parseInt(this.order.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/Order/create-order", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.order = res.data;
        this.isEdit = true;
        this.searchOrder(2);
        alert("New order has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateOrder() {
    var x = this.order;
    this.http.post("https://localhost:44395/api/Order/update-order", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.order = res.data;
        //this.isEdit = true;
        this.searchOrder(2);
        alert("New order has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteOrder(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.order = this.orders.data[index];
      var x:any  ={id: this.order.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/Order/delete-order", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchOrder(2);
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
