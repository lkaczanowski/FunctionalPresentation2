- title : Funkyjna kompozycja
- description : 
- author : Łukasz Kaczanowski
- theme : night
- transition : default

### Funkcyjna kompozycja

***

### Compose

    let compose f g x = g (f x)

    let (>>) = compose

***

### Functor

    [lang=haskell]
    fmap :: (a -> b) -> m a -> m b

***

### Applicative

    [lang=haskell]
    pure  :: a -> m a
    apply :: m (a -> b) -> m a -> m b

***

### Monad

    [lang=haskell]
    bind :: (a -> m b) -> m a -> m b

***

### Bonus : Kleisli

    [lang=haskell]
    arrow :: (a -> m b) -> (b -> m c) -> m a -> m c

***

### Podsumowanie

    [lang=haskell]
    fmap  ::   (a ->   b) -> m a -> m b
    apply :: m (a ->   b) -> m a -> m b
    bind  ::   (a -> m b) -> m a -> m b
***

### Linki

[http://fsharpforfunandprofit.com/](http://fsharpforfunandprofit.com/)
