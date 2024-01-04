export interface Client {
  id: number;
  name: string;
  surname: string;
  address: string;
  email: string;
  phoneNumbers?: PhoneNumber[]; // Assuming PhoneNumber is another model/interface
}

export interface PhoneNumber {
  type: string;
  number: string;
}
