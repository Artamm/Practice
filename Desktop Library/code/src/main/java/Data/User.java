package Data;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table (name="users")
public class User extends Person {
    public User(){}

    @Id
    @Column(name="id")
    public int userId;


    public list_Books user_books = new list_Books();

    @Column(name="Date")
    public String date ="";


    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public User (String name, String surname) {
       super(name,surname);
    }

    public void setUser_books(list_Books user_books) {
        this.user_books = user_books;
    }

    public String printAll(){ return "Name: " + this.getName().toUpperCase() + "\n Surname: "+ this.getSurname() +"\n"; }
}
