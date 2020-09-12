package Data;

import java.util.ArrayList;
import java.util.List;

public class list_Books {
    public int user_id;
    public String bookTitle;
    public String date;
    public List<Book> current_books = new ArrayList<>();
    public List<Book> old_books = new ArrayList<>();
    public List<Book> future_books = new ArrayList<>();


    public List<Book> getCurrent_books() {
        return current_books;
    }

    public void setCurrent_books(List<Book> current_books) {
        this.current_books = current_books;
    }

    public List<Book> getOld_books() {
        return old_books;
    }

    public void setOld_books(List<Book> old_books) {
        this.old_books = old_books;
    }

    public List<Book> getFuture_books() {
        return future_books;
    }

    public void setFuture_books(List<Book> future_books) {
        this.future_books = future_books;
    }

    public void addBook(List<Book> list, Book new_book){
        list.add(new_book);
    }

    public void removeBook(List<Book> list, Book new_book){
        list.remove(new_book);
    }

    public Book printCertainBook(List<Book> list, int number){
        return list.get(number);
    }

    @Override
    public String toString() {
        return super.toString();
    }
}
