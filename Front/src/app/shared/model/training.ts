import { Course } from "./course";

export class Training  {
    name: string = "";
    description: string = "";
    courses: Course[] = [];

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.description = obj.description;
          this.courses = obj.courses;
        }
      }
    
}