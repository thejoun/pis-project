USE forum;

CREATE TABLE authority (
	id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY(id)
);

CREATE TABLE user (
	id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    join_time TIMESTAMP DEFAULT NULL,
    authority_id SMALLINT UNSIGNED DEFAULT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(authority_id) REFERENCES authority(id) ON DELETE SET NULL
);

CREATE TABLE forum (
	id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    title VARCHAR(300) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    parent_forum_id SMALLINT UNSIGNED,
    create_time TIMESTAMP DEFAULT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(parent_forum_id) REFERENCES forum(id) ON DELETE CASCADE
);

CREATE TABLE forum_moderators (
	user_id SMALLINT UNSIGNED NOT NULL,
    forum_id SMALLINT UNSIGNED NOT NULL,
    FOREIGN KEY(user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY(forum_id) REFERENCES forum(id) ON DELETE CASCADE
);

CREATE TABLE thread (
	id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    title VARCHAR(300) NOT NULL,
    message VARCHAR(1000) NOT NULL,
    forum_id SMALLINT UNSIGNED NOT NULL,
    creator_id SMALLINT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT NULL,
    locked BOOLEAN NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (forum_id) REFERENCES forum(id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE thread_likes (
	thread_id SMALLINT UNSIGNED NOT NULL,
    user_id SMALLINT UNSIGNED NOT NULL,
    FOREIGN KEY (thread_id) REFERENCES thread(id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE post (
	id SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
    message VARCHAR(1000) NOT NULL,
    thread_id SMALLINT UNSIGNED NOT NULL,
    creator_id SMALLINT UNSIGNED NOT NULL,
    create_time TIMESTAMP DEFAULT NULL,
	PRIMARY KEY (id),
    FOREIGN KEY (thread_id) REFERENCES thread(id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE post_likes (
	user_id SMALLINT UNSIGNED NOT NULL,
	post_id SMALLINT UNSIGNED NOT NULL,
	FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
	FOREIGN KEY (post_id) REFERENCES post(id) ON DELETE CASCADE
);