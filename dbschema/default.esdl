module default {
    type Post {
      required postId: str;
      required title: str;
      required score: int32;
    };
    type User {
      required name: str;
    };
    type Book {
      name: str;
      author: str;
    };
}
