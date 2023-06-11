-- create table twittercopy.comments (
--     id int auto_increment primary key,
--     author_id int not null,
--     content varchar(2047) null,
--     creation_time datetime null,
--     constraint posts_author_fk foreign key (author_id) references twittercopy.users (id)
-- );
DROP TABLE twittercopy.comments;
CREATE TABLE twittercopy.comments (
    id int auto_increment primary key,
    author_id int not null,
    post_id int not null,
    content varchar(2047) null,
    creation_time datetime null,
    likes int not null,
    author_name varchar(2047) null
);
INSERT INTO twittercopy.comments (
        author_id,
        post_id,
        content,
        creation_time,
        likes,
        author_name
    )
VALUES (11, 1, 'First comment', NOW(), 0, "Mishas");