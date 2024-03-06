import { User } from "./User";

export class Course  {
    name: string = "";
    description: string = "";
    startDate!: Date;
    numOfModules: number = 0;
    duration: number = 0;
    candidates: User[] = [];
    mentor: User = new User();
    mentorId: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.description = obj.description;
          this.startDate = obj.startDate;
          this.numOfModules = obj.numOfModules;
          this.candidates = obj.candidates;
          this.mentor = obj.mentor;
          this.mentorId = obj.mentorId;
        }
      }
}