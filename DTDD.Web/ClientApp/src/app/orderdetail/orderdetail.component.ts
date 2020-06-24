import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-orderdetail',
  templateUrl: './orderdetail.component.html',
  styleUrls: ['./orderdetail.component.css']
})
export class OrderdetailComponent implements OnInit {

  Orderdetails: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  Orderdetail: any = {
    orderDetailId: 0,
    orderId: 0,
    productId: 0,
    price: "10.000.000",
    saleQuantity: 0
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchOrderdetail(1);
  }

  searchOrderdetail(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/OrderDetail/search-order-detail", x).subscribe(result => {
      this.Orderdetails = result;
      this.Orderdetails  = this.Orderdetails .data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.Orderdetails .page);
    console.log(this.Orderdetails .totalPages)
    if (this.Orderdetails.page < this.Orderdetails.totalPages) {
      let nextPage = this.Orderdetails.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/OrderDetail/search-order-detail", x).subscribe(result => {
        this.Orderdetails = result;
        this.Orderdetails = this.Orderdetails.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.Orderdetails .page > 1) {
      let nextPage = this.Orderdetails .page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/OrderDetail/search-order-detail", x).subscribe(result => {
        this.Orderdetails  = result;
        this.Orderdetails  = this.Orderdetails.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.Orderdetail = {
    orderDetailId: 0,
    orderId: 0,
    productId: 0,
    price: "",
    saleQuantity: 0
      }
    }
    else {
      this.isEdit = true;
      this.Orderdetail = this.Orderdetails.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addOrderdetail() {
    var x = this.Orderdetails;
    x.id = parseInt(this.Orderdetail.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/OrderDetail/create-order-detail", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.Orderdetail = res.data;
        this.isEdit = true;
        this.searchOrderdetail(1);
        alert("New order-detail has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateOrderdetail() {
    var x = this.Orderdetail;
    this.http.post("https://localhost:44395/api/OrderDetail/update-order-detail", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.Orderdetail = res.data;
        //this.isEdit = true;
        this.searchOrderdetail(1);
        alert("New order-detail has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteOrderdetail(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.Orderdetail = this.Orderdetails.data[index];
      var x:any  ={id: this.Orderdetail.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/OrderDetail/delete-order-detail", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchOrderdetail(1);
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
