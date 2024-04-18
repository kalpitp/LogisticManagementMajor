export class ResourceAllocation {

    public constructor(
        public id: number,
        public orderId: number,
        public driverId: number,
        public managerId: number,
        public vehicleId: number,
        public assignedDate: Date,
        public assignmentStatusId: number = 1 ,
        public isActive: boolean = true,
        public createdAt: Date ,
        public updatedAt: Date 
    ) { }
}


