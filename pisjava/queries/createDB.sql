USE twittercopy;

CREATE TABLE authority (
	authority_id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY(authority_id)
);

CREATE TABLE user (
	id INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    authority_id SMALLINT UNSIGNED DEFAULT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(authority_id) REFERENCES authority(id) ON DELETE SET NULL
);

CREATE TABLE thread (
	id INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    title VARCHAR(300) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    creator_id INT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (creator_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE tweet (
	id INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    message VARCHAR(1000) NOT NULL,
    thread_id INT UNSIGNED NOT NULL,
    creator_id INT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (id),
    FOREIGN KEY (thread_id) REFERENCES thread(id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE post_thumbs_up (
	user_id INT UNSIGNED NOT NULL,
	tweet_id INT UNSIGNED NOT NULL,
	FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
	FOREIGN KEY (tweet_id) REFERENCES tweet(id) ON DELETE CASCADE
);

CREATE TABLE post_thumbs_down (
	user_id INT UNSIGNED NOT NULL,
	tweet_id INT UNSIGNED NOT NULL,
	FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
	FOREIGN KEY (tweet_id) REFERENCES tweet(id) ON DELETE CASCADE
);

CREATE TABLE comment(
    id INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    message VARCHAR(1000) NOT NULL,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    creator_id INT UNSIGNED NOT NULL,
    tweet_id INT UNSIGNED NOT NULL,
    //
    PRIMARY KEY (id),
    FOREIGN KEY (tweet_id) REFERENCES tweet(id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE comment_thumbs_up (
    user_id INT UNSIGNED NOT NULL,
    comment_id INT UNSIGNED NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (comment_id) REFERENCES comment(id) ON DELETE CASCADE
);

CREATE TABLE comment_thumbs_down (
    user_id INT UNSIGNED NOT NULL,
    comment_id INT UNSIGNED NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (comment_id) REFERENCES comment(id) ON DELETE CASCADE
);