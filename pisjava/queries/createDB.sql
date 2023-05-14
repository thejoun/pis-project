USE twittercopy;

CREATE TABLE authority (
	authority_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY(authority_id)
);

CREATE TABLE user (
	user_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    authority_id SMALLINT UNSIGNED DEFAULT NULL,
    PRIMARY KEY(user_id),
    FOREIGN KEY(authority_id) REFERENCES authority(authority_id) ON DELETE SET NULL
);

CREATE TABLE thread (
	thread_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    title VARCHAR(300) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    creator_id SMALLINT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (thread_id),
    FOREIGN KEY (creator_id) REFERENCES user(user_id) ON DELETE CASCADE
);


CREATE TABLE post (
	post_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    message VARCHAR(1000) NOT NULL,
    thread_id SMALLINT UNSIGNED NOT NULL,
    creator_id SMALLINT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (post_id),
    FOREIGN KEY (thread_id) REFERENCES thread(thread_id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(user_id) ON DELETE CASCADE
);

CREATE TABLE post_thumbs_up (
	user_id SMALLINT UNSIGNED NOT NULL,
	post_id SMALLINT UNSIGNED NOT NULL,
	FOREIGN KEY (user_id) REFERENCES user(user_id) ON DELETE CASCADE,
	FOREIGN KEY (post_id) REFERENCES post(post_id) ON DELETE CASCADE
);

CREATE TABLE post_thumbs_down (
	user_id SMALLINT UNSIGNED NOT NULL,
	post_id SMALLINT UNSIGNED NOT NULL,
	FOREIGN KEY (user_id) REFERENCES user(user_id) ON DELETE CASCADE,
	FOREIGN KEY (post_id) REFERENCES post(post_id) ON DELETE CASCADE
);

CREATE TABLE comment(
    comment_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    message VARCHAR(1000) NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    creator_id SMALLINT UNSIGNED NOT NULL,
    post_id SMALLINT UNSIGNED NOT NULL,
    //
    FOREIGN KEY (post_id) REFERENCES post(post_id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(user_id) ON DELETE CASCADE
);

CREATE TABLE comment_thumbs_up (
    user_id SMALLINT UNSIGNED NOT NULL,
    comment_id SMALLINT UNSIGNED NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(user_id) ON DELETE CASCADE,
    FOREIGN KEY (comment_id) REFERENCES comment(comment_id) ON DELETE CASCADE
);

CREATE TABLE comment_thumbs_down (
    user_id SMALLINT UNSIGNED NOT NULL,
    comment_id SMALLINT UNSIGNED NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(user_id) ON DELETE CASCADE,
    FOREIGN KEY (comment_id) REFERENCES comment(comment_id) ON DELETE CASCADE
);