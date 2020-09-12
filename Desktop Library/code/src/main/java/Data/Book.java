package Data;
import View.*;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;
@Entity
@Table(name = "books")
public class Book {
    public Book() { }

    @Column(name="Title")
    public String title;
    private String text;
    @Column(name="Year")
    public int year;
    @Column(name="genre")
    public String genre ="Not set";
    public List<Author> authors =new ArrayList<Author>();

    public list_Reviews book_reviews;

    @Column (name="Date")
    public String date;

    @Column (name="id")
    public int number;
    @Column(name="Author")
    public String authorsString="";

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public Book(String title, int year) {
        this.title = title;

        this.year = year;

    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public int getYear() {
        return year;
    }

    public List<Author> getAuthors() {
        return authors;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public void addAuthor(Author author){
        authors.add(author);
    }
    public void removeAuthor(Author author){
        authors.remove(author);
    }
    public void removeAllAuthors(){
        authors.removeAll(authors);
    }


    public list_Reviews getBook_reviews() { return book_reviews; }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public void setBook_reviews(list_Reviews book_reviews) {
        this.book_reviews = book_reviews;
    }

    public String printAll(){
        return "Title: " + this.getTitle().toUpperCase() + "\n Text: "+ this.getText()+"\n Year: "+ getYear() +"\n Genre: "+this.getGenre()+ "\n Author(s):" + getAuthors();
    }

    public String strigAuthors(){
        String data="";

        for (Author author :authors){
            data= data+author.getName()+" "+author.getSurname()+",";
        }
        this.authorsString=data;
        return data;
    }

    public void setAuthors(List<Author> authors) {
        this.authors = authors;
    }

    public void setAuthorsString(String authorsString) {
        this.authorsString = authorsString;
    }

    public String getAuthorsString() {
        return authorsString;

    }
}
