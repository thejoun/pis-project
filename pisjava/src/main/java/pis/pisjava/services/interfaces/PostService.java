package pis.pisjava.services.interfaces;

import pis.pisjava.dtos.PostDto;

import java.util.List;

public interface PostService {
    List<PostDto> getPosts();
}
