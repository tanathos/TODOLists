<template>
  <div>
    <nuxt-link to="/">
      <h1 class="text-6xl">
        Nuxt-TODOList
      </h1>
    </nuxt-link>
    <nuxt-link to="/todos/create">
      Create new
    </nuxt-link>
  </div>
</template>

<script>
export default {
  name: "AppHeader"
}
</script>
