import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  imports: [CommonModule, PaginationModule.forRoot()],
  exports: [PaginationModule]
})
export class SharedModule {}
