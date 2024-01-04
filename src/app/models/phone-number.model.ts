export interface PhoneNumber {
  id: number;
  number: string;
  type: NumberType; 
  clientId: number;
}

export enum NumberType {
  Home = 'Home',
  Work = 'Work',
  Mobile = 'Mobile',
}
