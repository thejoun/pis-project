package pis.pisjava.entities;


import jakarta.persistence.*;
import lombok.Data;


@Entity
@Table(name="post")
@Data
public class Post {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name="post_id")
    private int postId;

    @Column(name="message")
    private String message;

    public Post() {
    }

    public Post(int postId, String message) {
        this.postId = postId;
        this.message = message;
    }
}
