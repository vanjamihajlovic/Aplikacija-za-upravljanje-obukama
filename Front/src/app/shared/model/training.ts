export class Training  {
    name: string = "";
    description: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.description = obj.description;
        }
      }
    
}