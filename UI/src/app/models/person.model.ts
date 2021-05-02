export class Person {
  id: number;
  name: string;
  document: string;
  email: string;
  birthDate: Date;
  phoneNumber?: string;

  constructor(other?: any) {
    if (other != null) {
      this.id = other.id;
      this.name = other.name;
      this.document = other.document;
      this.email = other.email;
      this.birthDate = other.birthDate;
      this.phoneNumber = other.phoneNumber;
    } else {
      this.id = 0;
      this.name = '';
      this.email = '';
      this.document = '';
      this.birthDate = new Date();
    }

  }

}
