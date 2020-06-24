import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  product: any = {
    id: 0,
    productName: "SAMSUNG",
    idCat: 0,
    title: "Samsung Galaxy A91",
    description: "Máy ảnh chuyên nghiệp thu nhỏ",
    quantity: 0,
    price: "10.000.000"
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchProduct(1);
  }

  searchProduct(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post("https://localhost:44395/api/Product/search-product", x).subscribe(result => {
      this.products = result;
      this.products = this.products.data;

    }, error => console.error(error));
  }
  searchNext() {
    console.log(this.products.page);
    console.log(this.products.totalPages)
    if (this.products.page < this.products.totalPages) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Product/search-product", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the last page!");
    }
  }
  searchPrevious() {
    if (this.products.page > 1) {
      let nextPage = this.products.page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post("https://localhost:44395/api/Product/search-product", x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;

      }, error => console.error(error));
    }
    else {
      alert("You are at the first page!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.product = {
        id: 0,
        idCat: 12,
        productName: "",
        title: "",
        description: "",
        price: "",
        quantity: 0,
        size: "",
        weight: "",
        color: "",
        image: "",
        memory: "",
        os: "",
        cpuSpeed: "",
        cameraPrimary: "",
        battery: "",
        bluetooth: "",
        wlan: "",
        promotionPrice: ""
      }
    }
    else {
      this.isEdit = true;
      this.product = this.products.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addProduct() {
    var x = this.product;
    x.id = parseInt(this.product.id);
    console.log(x);
    this.http.post("https://localhost:44395/api/Product/create-product", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.product = res.data;
        this.isEdit = true;
        this.searchProduct(1);
        alert("New product has been added successfully!");
      }
    }, error => console.error(error));
  }

  UpdateProduct() {
    var x = this.product;
    this.http.post("https://localhost:44395/api/Product/update-product", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.product = res.data;
        //this.isEdit = true;
        this.searchProduct(1);
        alert("New product has been updated successfully!");
      }

    }, error => console.error(error));
  }

  deleteProduct(index) {
    var r =confirm("Are you sure you want to permanently delete this item?");
    if(r == true) {
      this.product = this.products.data[index];
      var x:any  ={id: this.product.id};
      console.log(x);
      this.http.post("https://localhost:44395/api/Product/delete-product", x).subscribe(result => {
        var res:any =result;
        if(res.success){
          this.searchProduct(1);
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
