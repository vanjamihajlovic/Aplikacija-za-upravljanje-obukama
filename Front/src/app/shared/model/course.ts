import { User } from "./User";

export class Course  {
    name: string = "";
    description: string = "";
    startDate!: Date;
    nModules: number = 0;
    duration: number = 0;
    candidates: User[] = [];
    mentor!: User

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.description = obj.description;
          this.startDate = obj.startDate;
          this.nModules = obj.nModules;
          this.candidates = obj.candidates;
          this.mentor = obj.mentor;
        }
      }
    
}