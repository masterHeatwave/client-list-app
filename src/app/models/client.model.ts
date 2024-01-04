export interface Client {
  id: number;
  name: string;
  surname: string;
  address: string;
  email: string;
  phoneNumbers?: PhoneNumber[]; 
}

export interface PhoneNumber {
  type: string;
  number: string;
}
