export class User {
    email: string = "";
    firstName: string = "";
    lastName: string = "";
    role: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.email = obj.email;
          this.firstName = obj.firstName;
          this.lastName = obj.lastName;
          this.role = obj.role;
        }
      }
    
}