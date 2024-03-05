export class Credentials implements ICredentials {
    email: string = "";
    password: string = "";

    public constructor(obj?: any) {
        if (obj) {
          this.email = obj.email;
          this.password = obj.password;
        }
      }
    
}

export interface ICredentials {
    email: string,
    password: string
};