package Data;

import java.util.ArrayList;
import java.util.List;

public class list_Reviews {

    public List<Review> positive_reviews= new ArrayList<Review>();
    public List<Review> negative_reviews= new ArrayList<Review>();
    public List<Review> neutral_reviews= new ArrayList<Review>();

    public List<Review> getPositive_reviews() {
        return positive_reviews;
    }

    public List<Review> getNegative_reviews() {
        return negative_reviews;
    }

    public List<Review> getNeutral_reviews() {
        return neutral_reviews;
    }

    public void setPositive_reviews(List<Review> positive_reviews) {
        this.positive_reviews = positive_reviews;
    }

    public void setNegative_reviews(List<Review> negative_reviews) {
        this.negative_reviews = negative_reviews;
    }

    public void setNeutral_reviews(List<Review> neutral_reviews) {
        this.neutral_reviews = neutral_reviews;
    }

    public void addReview(List<Review> list, Review review){
        list.add(review);
    }
}
