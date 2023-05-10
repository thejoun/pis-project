package pis.pisjava.services;

import org.springframework.stereotype.Service;
import pis.pisjava.dtos.PostDto;
import pis.pisjava.entities.Post;
import pis.pisjava.repositories.PostRepository;
import pis.pisjava.services.interfaces.PostService;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class PostServiceImpl implements PostService {

    private PostRepository postRepository;

    public PostServiceImpl(PostRepository postRepository) {
        this.postRepository = postRepository;
    }


    public List<PostDto> getPosts() {
        List<Post> list = postRepository.findAll();
        List<PostDto> listOfDtos = list.stream().map(post -> new PostDto(post.getMessage())).collect(Collectors.toList());
        return listOfDtos;
    }
}
