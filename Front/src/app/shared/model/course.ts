export class Course  {
    name: string = "";
    description: string = "";
    startDate!: Date;
    nModules: number = 0;
    

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.description = obj.description;
        }
      }
    
}