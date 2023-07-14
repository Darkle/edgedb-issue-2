CREATE MIGRATION m15hihdbja4lojiwa4vb3md3le2t5e2cn3yxgdkktmjqoqkgsdpkfq
    ONTO m1mp4cksws6ycv4knzgljmbidvlrsoivc2h64dywtjpi4hs6alrwiq
{
  CREATE TYPE default::Book {
      CREATE PROPERTY author: std::str;
      CREATE PROPERTY name: std::str;
  };
  ALTER TYPE default::Post {
      ALTER PROPERTY postId {
          RESET readonly;
      };
  };
  ALTER TYPE default::User {
      ALTER PROPERTY name {
          RESET readonly;
      };
  };
};
