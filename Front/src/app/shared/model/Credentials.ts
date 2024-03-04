export class Credentials implements ICredentials {
    email: string = "";
    password: string = "";

    constructor() {
    }
    
}

export interface ICredentials {
    email: string,
    password: string
};