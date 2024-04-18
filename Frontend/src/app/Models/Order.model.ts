export class Order{
    public constructor(public id:number, public userId:number,public userName:string, public orderDate:Date, public totalAmount:number , public orderDetailId:number,public inventoryId:number,public inventoryName:string, public quantity:number, public subTotal:number, public orderStatusId:number, public originId:boolean, public destinationId:number, public statusId:number,
        public  status:string|null,public isActive:boolean , public createdAt:Date,){}   
}
