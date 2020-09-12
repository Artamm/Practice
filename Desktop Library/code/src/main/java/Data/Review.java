package Data;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="reviews")
public class Review {
public Review(){}
    @Id
    public int id;
    @Column(name="user_id")
    public int user_id;
    @Column(name="book")
    public String book;
    @Column (name="review")
    public String text;
    @Column(name="rate")
    private int rate;
    private User review_author;
    @Column(name="date")
    private String date;

    public Review(int id, int user_id, String book,int rate, String text, String date ) {
        this.id = id;
        this.user_id=user_id;
        this.book=book;
        this.rate=rate;
        this.text=text;
        this.date=date;
    }

    public String getText() {
        return text;
    }

    public int getRate() {
        return rate;
    }


    public User getReview_author() {
        return review_author;
    }

    public void setText(String text) {
        this.text = text;
    }

    public void setRate(int rate) {
        this.rate = rate;
    }

    public void setReview_author(User review_author) {
        this.review_author = review_author;
    }

    public String getInformation(){return "Author of the review:" + getReview_author() + "\n Rated: " + getRate()+"\n"+ getText(); }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getUser_id() {
        return user_id;
    }

    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }


    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getBook() {
        return book;
    }

    public void setBook(String book) {
        this.book = book;
    }
}
