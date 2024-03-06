export class TableCandidates {
    name: string = "";
    feedback: string = "";
    duration: string = "";
    rating: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.feedback = obj.feedback;
          this.duration = obj.duration;
          this.rating = obj.rating;
       
        }
    }
}