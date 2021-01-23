<template>
  <div style="display: flex">
    <nuxt-link to="/" class="xl:w-6/12" style="flex: auto">
      <h1 class="text-6xl">
        Nuxt-TODOList
      </h1>
    </nuxt-link>
    <nuxt-link to="/todos/create" class="xl:w-6/12" style="flex: auto; text-align:right; padding: 20px;">
      Create new
    </nuxt-link>
  </div>
</template>

<script>
export default {
  name: "AppHeader"
}
</script>
