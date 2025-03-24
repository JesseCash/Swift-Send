CREATE DEFINER=`hristo`@`localhost` PROCEDURE `AuthenticateUser`(
    IN username VARCHAR(50),
    IN password VARCHAR(64)
)
BEGIN
    DECLARE salt VARCHAR(64);
    DECLARE hashedInputPassword VARCHAR(64);

    -- Retrieve the user's salt
    SELECT salt INTO salt FROM users WHERE username = username;

    -- Check if salt exists
    -- IF salt IS NULL THEN
       --  SELECT 0 AS Authenticated;  -- Authentication failed
    -- ELSE
        -- Hash the combined salt and password
        -- SET hashedInputPassword = SHA2(CONCAT(salt, password), 256);
		SET hashedInputPassword = password;
        -- Check if the computed hash matches the stored password hash
        IF EXISTS (SELECT 1 FROM users WHERE username = username AND hashedPassword = hashedInputPassword) THEN
            SELECT 1 AS Authenticated;  -- Authentication successful
        ELSE
            SELECT 0 AS Authenticated;  -- Authentication failed
        END IF;
    -- END IF;
END