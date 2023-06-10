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
    creation_time datetime null
);
INSERT INTO twittercopy.comments (author_id, post_id, content, creation_time)
VALUES (11, 1, 'First comment', NOW());