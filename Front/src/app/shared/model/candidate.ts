export class Candidate {
    name: string = "";
    surname: string = "";
    email: string = "";
    password: string = "";
    address: string = "";


    public constructor(obj?: any) {
        if (obj) {
          this.name = obj.name;
          this.surname = obj.surname;
          this.email = obj.email;
          this.password = obj.password;
          this.address = obj.address;
        }
      }
}
