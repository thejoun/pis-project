package pis.pisjava.dtos;

import lombok.Data;

@Data
public class PostDto {
    public String message;

    public PostDto() {
    }

    public PostDto(String message) {
        this.message = message;
    }
}
