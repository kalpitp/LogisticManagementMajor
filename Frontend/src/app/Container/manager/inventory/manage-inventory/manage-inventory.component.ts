import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { InventoryCategoryService } from '../../../../Services/Manager/inventory-category.service';
import { InventoryCategory } from '../../../../Models/InventoryCategory.model';

@Component({
  selector: 'app-manage-inventory',
  templateUrl: './manage-inventory.component.html',
  styleUrl: './manage-inventory.component.scss'
})
export class ManageInventoryComponent  implements OnInit {
  InventoryForm:FormGroup;
  inventoryCategories:InventoryCategory[] = [];

  constructor(private formBuilder:FormBuilder){}
  inventoryCategoryService:InventoryCategoryService = inject(InventoryCategoryService);
  getInventoryCategories(){
    this.inventoryCategoryService.getInventories().subscribe({
      next:(response)=>{
        this.inventoryCategories = response.data as InventoryCategory[];
      }
    })
  }
  ngOnInit(): void {
    this.getInventoryCategories();
    this.InventoryForm= new FormGroup({
      name: new FormControl('',[Validators.required, Validators.pattern(/^(?=.*[a-zA-Z0-9])[a-zA-Z0-9\s]{1,100}$/)]),
      category: new FormControl('default',[Validators.required]),
      description: new FormControl('',[Validators.required, Validators.pattern(/^.{5,500}$/)]),
      quantity: new FormControl(0,[Validators.required, Validators.pattern(/^[1-9]\d*$/)]),
      price: new FormControl(0,[Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]),
      imageURL: new FormControl('',[Validators.required]),
    })
  }

  onFormSubmit(){
    if(this.InventoryForm.valid){
      console.log(this.InventoryForm.value);     
  }
  }
}
