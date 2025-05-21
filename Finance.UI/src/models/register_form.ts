export interface IRegisterForm{
    Email: string,
    Password: string,
    ConfirmPassword: string
}

export class RegisterForm implements IRegisterForm{
    public Email: string = '';
    public Password: string = '';
    public ConfirmPassword: string = '';
}