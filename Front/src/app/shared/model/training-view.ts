
export class TrainingView  {
    id: string = "";
    name: string = "";
    description: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.id = obj.id;
          this.name = obj.name;
          this.description = obj.description;
        }
      }
    
}