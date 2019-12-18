export class ContactUs {
  /*[Required(ErrorMessage = "Please provide valid name to contact you.")]*/
  public Name: string;
  /*[Required]
          [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]*/
  public Email: string;
  /*[Required(ErrorMessage = "Please provide message with in 50 words."), MaxLength(100)]*/
  public Message: string;
}
