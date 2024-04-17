export class Inventory{
    public constructor(public id:number, public name:string, public image:string, public description:string, public stock:number, public price:number,public categoryId:number ,public categoryName:string, public warehouseId:number,public IsActive:boolean, public createdAt:Date, public updatedAt:Date){}
}
