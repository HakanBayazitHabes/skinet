import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PaginHeaderComponent } from './pagin-header/pagin-header.component';
import { PagerComponent } from './pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './order-totals/order-totals.component'
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PaginHeaderComponent, PagerComponent, OrderTotalsComponent],
  imports: [CommonModule, PaginationModule.forRoot(), CarouselModule.forRoot(), ReactiveFormsModule],
  exports: [PaginationModule, PaginHeaderComponent, PagerComponent, CarouselModule, OrderTotalsComponent,ReactiveFormsModule],
})
export class SharedModule { }
